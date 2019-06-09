using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Plugin.Fingerprint.Dialog;

namespace PinkyBankingForms.Droid
{
    public class CustomDialogFragment : FingerprintDialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            view.Background = new ColorDrawable(Color.Magenta);
            return view;
        }
    }
}
