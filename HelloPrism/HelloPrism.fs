namespace HelloPrism

open Xamarin.Forms
open Prism.Unity
open HelloPrism.Views

type App() = 
    inherit PrismApplication()

    override this.OnInitialized() = 
        this.NavigationService.NavigateAsync("MainPage") |> Async.AwaitTask |> Async.RunSynchronously

    override this.RegisterTypes() = 
        this.Container.RegisterTypeForNavigation<MainPage>() |> ignore
