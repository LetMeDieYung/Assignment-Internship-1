# EVENT API

## API Endpoint: /api/event

### HTTP Method: GET

Description: Retrieves the list of events

Request:
```bash
GET /api/event/events
```
Response:
```yaml
Status Code: 200
Returns: EventListVm object
```
### HTTP Method: POST

Description: Creates a new event

Request:
```bash
POST /api/event

{
    "title": "event title",
    "description": "event Description",
    "startDateTime": "event StartDateTime",
    "endDateTime": "event EndDateTime",
    "imageId": "event ImageId",
    "spaceId": "event SpaceId",
    "tickets": "Quantity event Tickets"
}
```
Response:
```yaml
Status Code: 201
Returns: Id (guid) of the created event
```
### HTTP Method: PUT

Description: Updates an existing event

Request:
```bash
PUT /api/event

{
    "title": "update event title",
    "description": "update event Description",
    "startDateTime": "update event StartDateTime",
    "endDateTime": "update event EndDateTime",
    "imageId": "update event ImageId",
    "spaceId": "update event SpaceId",
    "tickets": "update Quantity event Tickets"
}
```
Response:
```yaml
Status Code: 204
Returns: NoContent
```
### HTTP Method: DELETE

Description: Deletes an event by ID

Request:
```bash
DELETE /api/event/{id}
```
Response:
```yaml
Status Code: 204
Returns: NoContent
```
