using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace AnimatedTabs
{
    public partial class MainTabBarViewController : UITabBarController
    {
        private CustomTransitioningDelegate swipeDelegate;
        public MainTabBarViewController(IntPtr handle) : base(handle)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            swipeDelegate = new CustomTransitioningDelegate(ViewControllers);
            Delegate = swipeDelegate;
        }
    }
}