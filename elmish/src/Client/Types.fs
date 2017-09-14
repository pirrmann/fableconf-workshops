module App.Types

open Okular.Lens

type Msg =
    | AdminMsg of Admin.Dispatcher.Types.Msg
    | HomeMsg of Home.Types.Msg
    | SignInMsg of SignIn.Types.Msg

type Model =
    { CurrentPage : Page
      AdminModel : Admin.Dispatcher.Types.Model
      Home : Home.Types.Model
      SignIn : SignIn.Types.Model
      Session : Session option }

    static member AdminModelLens =
        { Get = fun (r : Model) -> r.AdminModel
          Set = fun v (r : Model) -> { r with AdminModel = v } }
