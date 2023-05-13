# ThumbnailService

## Installation
In the solution folder, run the command: 
  ```
  docker compose up
  ```

## Consuming API
### POST
endpoint: 
```
localhost/Thumbnail
```
body: 
```
{
  "url": "https://images.freeimages.com/images/previews/ac9/railway-hdr-1361893.jpg",
  "sizeX": 200,
  "sizeY": 200
}
```

response:
```
Guid
```

### GET
endpoint: 
```
localhost/Thumbnail?id={Guid from post request}
```
response:
```
{
    "thumbnailUid": "0e529a39-6bd8-49ea-8beb-26ecde055cb3",
    "status": "IN_QUEUE",
    "errorMessage": null
}
```
or thumbnail if processing is completed
