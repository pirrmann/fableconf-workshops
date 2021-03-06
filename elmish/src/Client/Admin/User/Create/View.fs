module Admin.User.Create.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Extra.FontAwesome
open Fulma.Elements.Form
open Fulma.Layouts

let textField label icon (field: StringField) (msg: string -> Msg) dispatch =
    Field.field_div [ ]
      [ yield Label.label [ ]
                [ str label ]
        yield Control.control_div [ Control.hasIconLeft ]
                [ Icon.faIcon [ Icon.isSmall ] icon
                  Input.text [ Input.defaultValue field.Value
                               Input.props [ OnChange (fun ev -> msg !!ev.target?value |> dispatch) ] ] ]
        if field.Error.IsSome then
            yield Help.help [ Help.isDanger ]
                    [ str field.Error.Value ] ]

let root model dispatch =
    Columns.columns [ Columns.isCentered ]
        [ Column.column [ Column.Width.isHalf ]
            [ form [ ]
                [ textField "Firstname" Fa.User model.FormData.Firstname ChangeFirstname dispatch
                  textField "Surname" Fa.User model.FormData.Surname ChangeSurname dispatch
                  textField "Email" Fa.EnvelopeO model.FormData.Email ChangeEmail dispatch
                  textField "Password" Fa.Key model.FormData.Password ChangePassword dispatch
                  textField "Password Confirmation" Fa.Key model.FormData.PasswordConfirmation ChangePasswordConfirmation dispatch

                  Field.field_div [ Field.isGrouped
                                    Field.Types.CustomClass Fulma.BulmaClasses.Bulma.Properties.Float.IsPulledRight ]
                    [ Control.control_div [ ]
                        [ Button.button [ Button.isPrimary
                                          Button.onClick (fun _ -> dispatch Submit) ]
                            [ str "Create user" ] ]
                      Control.control_div [ ]
                        [ Button.button [ Button.isLink
                                          Button.onClick (fun _ -> dispatch Cancel) ]
                            [ str "Cancel" ] ] ] ] ] ]
