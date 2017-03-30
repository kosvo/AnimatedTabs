using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace AnimatedTabs
{
    public class CustomTransitioningDelegate : UITabBarControllerDelegate
    {
        private List<UIViewController> viewControllers;
        private IUIViewControllerAnimatedTransitioning animator;

        public CustomTransitioningDelegate(UIViewController[] controllers)
        {
            viewControllers = new List<UIViewController>(controllers);
        }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForTransition(UITabBarController tabBarController, UIViewController fromVC, UIViewController toVC)
        {
            var sIndex = viewControllers.IndexOf(fromVC);
            var dIndex = viewControllers.IndexOf(toVC);
            animator = new TabBarSlideTransitionAnimation(sIndex, dIndex);
            return animator;
        }
    }
    
}