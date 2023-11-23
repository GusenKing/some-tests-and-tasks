open System.Threading

type Message =
    | BlankName
    | NameTooLong

type Result<'TEntity> =
    | Success of 'TEntity 
    | Failure of Message

let bind switchFunction =
    fun twoTrackInput ->
        match twoTrackInput with
        | Success s -> switchFunction s
        | Failure f -> Failure f

let (>>=) twoTrackInput switchFunction =
    bind switchFunction twoTrackInput

let map singleTrackFunction twoTrackInput =
    match twoTrackInput with
    | Success s -> Success (singleTrackFunction s)
    | Failure f -> Failure f
    
let tee deadEndFunction oneTrackInput =
    deadEndFunction oneTrackInput
    oneTrackInput

let receiveRequest token=
    Success "some request"

let nameNotBlank (input : string) =
    if input.Length = 0 then Failure BlankName
    else Success input

let name50 (input : string) =
    if input.Length > 50 then Failure NameTooLong
    else Success input

let validateRequest twoTrackInput : Result<string> =
    twoTrackInput
    >>= nameNotBlank
    >>= name50

let canonicalizeEmailLogic (input : string) =
    input.ToLower().Trim()

let canonicalizeEmail input =
    map canonicalizeEmailLogic input

let updateDbLogic request =
    //some db updating logic 
    ()

let updateDbFromRequest request =
    tee updateDbLogic request

let sendEmailLogic request =
    //email sending logic
    ()
    
    
    
    
let sendEmail request =
    tee sendEmailLogic request

let returnMessage result =
    match result with
    | Success s -> "success"
    | Failure err ->
        match err with
        | BlankName -> "Name must not be blank"
        | NameTooLong -> "Name mist be shorter"

let updateCustomerWithErrorHandling =
    receiveRequest
    >> validateRequest
    >> canonicalizeEmail
    >> updateDbFromRequest
    >> sendEmail
    >> returnMessage

let result = updateCustomerWithErrorHandling 1