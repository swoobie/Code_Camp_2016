using UnityEngine;
using Leap.Unity.Attributes;
using System.Collections;

namespace Leap.Unity { 

    public class ThumbsUpDetector : Detector {
        public float Period = .1f; //seconds

        [AutoFind(AutoFindLocations.Parents)]
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public IHandModel HandModel = null;

        public PointingState Thumb = PointingState.Extended;
        public PointingState Index = PointingState.NotExtended;
        public PointingState Middle = PointingState.NotExtended;
        public PointingState Ring = PointingState.NotExtended;
        public PointingState Pinky = PointingState.NotExtended;

        [Range(0, 5)]
        public int MinimumExtendedCount = 1;
        [Range(0, 5)]
        public int MaximumExtendedCount = 1;

        private IEnumerator watcherCoroutine;

        void Awake() {
            watcherCoroutine = ThumbsUpWatcher();
        }

        void OnEnable() {
            StartCoroutine(watcherCoroutine);
        }

        void OnDisable() {
            StopCoroutine(watcherCoroutine);
            Deactivate();
        }

        IEnumerator ThumbsUpWatcher() {
            Hand hand;
            while (true) {
                bool fingerState = false;
                if (HandModel != null && HandModel.IsTracked) {
                    hand = HandModel.GetLeapHand();
                    if (hand != null) {
                        fingerState = matchFingerState(hand.Fingers[0], Thumb)
                              && matchFingerState(hand.Fingers[1], Index)
                              && matchFingerState(hand.Fingers[2], Middle)
                              && matchFingerState(hand.Fingers[3], Ring)
                              && matchFingerState(hand.Fingers[4], Pinky);
                    }

                    int extendedCount = 0;
                    for (int f = 0; f < 4; f++) {
                        if (hand.Fingers[f].IsExtended) {
                            extendedCount++;
                        }
                    }

                    fingerState = fingerState &&
                         (extendedCount <= MaximumExtendedCount) &&
                         (extendedCount >= MinimumExtendedCount);

                    if (HandModel.IsTracked && fingerState) {
                        Activate();
                    } else if (!HandModel.IsTracked || !fingerState) {
                        Deactivate();
                    }

                } else if (IsActive) {
                    Deactivate();
                }
                yield return new WaitForSeconds(Period);
            }
        }

        private bool matchFingerState(Finger finger, PointingState requiredState) {
            return (requiredState == PointingState.Either) ||
                   (requiredState == PointingState.Extended && finger.IsExtended) ||
                   (requiredState == PointingState.NotExtended && !finger.IsExtended);
        }

#if UNITY_EDITOR
        void OnDrawGizmos() {
            if (ShowGizmos && HandModel != null) {
                PointingState[] state = { Thumb, Index, Middle, Ring, Pinky };
                Hand hand = HandModel.GetLeapHand();
                int extendedCount = 0;
                int notExtendedCount = 0;
                for (int f = 0; f < 5; f++) {
                    Finger finger = hand.Fingers[f];
                    if (finger.IsExtended) extendedCount++;
                    else notExtendedCount++;
                    if (matchFingerState(finger, state[f]) &&
                       (extendedCount <= MaximumExtendedCount) &&
                       (extendedCount >= MinimumExtendedCount)) {
                        print("Thumbs up!");
                    } else {
                        //print("nope");
                    }
                }
            }
        }
#endif
    }

    /** Defines the settings for comparing extended finger states */
    //public enum PointingState { Extended, NotExtended, Either }
}