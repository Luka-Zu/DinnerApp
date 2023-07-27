# API CALLS

## /Auth/Register [PostReq]
Desc: Request for Sign up 

Request Body Example:
```json
{
	"FirstName": "Luka",
	"LastName": "Zukhbaia",
	"Email": "ZukhbaiaLuka0@gmail.com",
	"Password": "Paroli123"
}
```
```js
200 OK
```

Response Body Example:
```json
{
	"id":"00000000-0000-0000-0000-000000000000",
	"firstName":"Luka",
	"lastName":"Zukhbaia",
	"email":"ZukhbaiaLuka0@gmail.com",
	"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhOTA1ZTVjZC1kMjI1LTQ3ZDktOTJlNC02YmU4NGFmM2VhNGEiLCJnaXZlbl9uYW1lIjoiTHVrYSIsImZhbWlseV9uYW1lIjoiWnVraGJhaWEiLCJqdGkiOiIwYjYxNjA1NC1lZmEyLTQ2MjUtOTYyYy02YTg1NjAzZTRjNGQiLCJleHAiOjE2OTA0NDcwMTEsImlzcyI6IkRpbm5lciBBcHAiLCJhdWQiOiJEaW5uZXIgQXBwIn0.KAqL41M56gsnELWZzQDbEyJsatqQVr-oz3QKfTGKhXw"
}
```
## /Auth/Login [PostReq]
Desc: Request for Sign in

Request Body Example:
```json   
{
   "Email": "ZukhbaiaLuka0@gmail.com",
   "Password": "Paroli123"
}
```
Response Body Example:
