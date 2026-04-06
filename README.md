# example-web-server


## API endpoints documentation

### Health check

GET {url}/api/health
Returns: OK


### Books endpoints

Base api route: {url}/api/books

###
GET
###
Returns: Pagination of Book DTO
##
Example:
```
{
  "data": [
    {
      "id": "888aa54c-d915-4435-b4a2-40cbe074f0c3",
      "name": "The Hobbit or There and Back Again",
      "description": "An adventure book",
      "pageCount": 310,
      "authorName": "J.R.R Tolkien"
    },
    {
      "id": "91363e1f-e10c-4970-af79-96d38873a541",
      "name": "The Myth of Sisyphus",
      "description": "A philosophical work discussing meaning of absurd in humans' life ",
      "pageCount": 185,
      "authorName": "Albert Camus"
    }
  ],
  "count": 2,
  "pageSize": 10,
  "pageIndex": 1
}
```
POST
###
Request body:
```
{
  "Name":string,
  "Description:string,
  "PageCount":int,
  "AuthorName":string
}
```
UPDATE {id}
###
Request body:
```
{
  "Name":string,
  "Description:string,
  "PageCount":int,
  "AuthorName":string
}
```

DELETE {id}
