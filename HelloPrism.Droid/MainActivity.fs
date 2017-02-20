namespace HelloPrism.Droid

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Xamarin.Forms
open Xamarin.Forms.Platform.Android

type Resources = HelloPrism.Droid.Resource

[<Activity (Label = "HelloPrism", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit FormsApplicationActivity ()

    override this.OnCreate (bundle) =
        base.OnCreate (bundle)

        Forms.Init(this, bundle)
        this.LoadApplication(new HelloPrism.App())



