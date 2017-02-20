namespace HelloPrism.ViewModels

open System
open Prism.Commands
open Prism.Mvvm
open Prism.Services
open System.Diagnostics

type MainPageViewModel(pageDialogService: IPageDialogService) = 
    inherit BindableBase()

    let displayAlert () = 
        let result = pageDialogService.DisplayAlertAsync("Alert", "This is an alert from MainPageViewModel.", "Accept", "Cancel")
        async {
            let! r = result |> Async.AwaitTask
            Debug.WriteLine(r)
        } |> Async.Start
    
    let displayActionSheet () =
        let result = pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destroy", "Option 1", "Option 2")
        async {
            let! r = result |> Async.AwaitTask
            Debug.WriteLine(r)
        } |> Async.Start

    let displayActionSheetUsingActionSheetButtons () = 

        let option1Action = ActionSheetButton.CreateButton("Option 1", new DelegateCommand(fun () ->  Debug.WriteLine("Option 1") ))
        let option2Action = ActionSheetButton.CreateButton("Option 2", new DelegateCommand(fun () ->  Debug.WriteLine("Option 2") ))
        let cancelAction = ActionSheetButton.CreateCancelButton("Cancel", new DelegateCommand(fun () ->  Debug.WriteLine("Cancel") ))
        let destroyAction = ActionSheetButton.CreateDestroyButton("Destroy", new DelegateCommand(fun () ->  Debug.WriteLine("Destroy") ))

        pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", option1Action, option2Action, cancelAction, destroyAction) |> ignore
        ()

    member val DisplayAlertCommand = new DelegateCommand(Action(fun () -> Debug.WriteLine("Display alert"); displayAlert ()))
    member val DisplayActionSheetCommand = DelegateCommand(fun () -> Debug.WriteLine("Display alert sheet");  displayActionSheet())
    member val DisplayActionSheetUsingActionSheetButtonsCommand = DelegateCommand(fun () -> Debug.WriteLine("Display alert with buttons");  displayActionSheetUsingActionSheetButtons())


    
