using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace AnimatedTabs
{

    public class TabBarSlideTransitionAnimation : UIViewControllerAnimatedTransitioning
    {
        int fromIndex;
        int toIndex;
        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {

            var fromView = transitionContext.GetViewFor(UITransitionContext.FromViewKey);
            var toView = transitionContext.GetViewFor(UITransitionContext.ToViewKey);

            transitionContext.ContainerView?.AddSubview(fromView);

            transitionContext.ContainerView?.AddSubview(toView);

            var fromLtoR = fromIndex > toIndex;

            var displayFrame = toView.Frame;

            toView.Alpha = 0;

            toView.Frame = new CoreGraphics.CGRect()
            {
                X = (fromLtoR == true ? -1 : 1) * toView.Frame.Width,
                Y = 0,
                Width = toView.Frame.Width,
                Height = toView.Frame.Height
            };

            var fromNewFrame = new CoreGraphics.CGRect()
            {
                X = (fromLtoR == true ? 1 : -1),
                Y = 0,
                Width = fromView.Frame.Width,
                Height = fromView.Frame.Height
            };

            UIView.Animate(TransitionDuration(transitionContext),
                                       delay: 0,
                           completion: () => transitionContext.CompleteTransition(true),
                           options: UIViewAnimationOptions.CurveEaseOut,
                           animation: () =>
                           {
                               toView.Frame = displayFrame;

                               toView.Alpha = 1;

                               fromView.Frame = fromNewFrame;
                           });
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext) => 0.3;

        public TabBarSlideTransitionAnimation(int fromIndex, int toIndex)
        {
            this.fromIndex = fromIndex;

            this.toIndex = toIndex;
        }
    }
    
}