## Query conference and it's related graph.

```
query{
  conferenceById(id:"Q29uZmVyZW5jZQppMQ==")
  {
    id,
    name,
    tracks{
      name
    },
    sessions{
      id,
      tags{
        name
      }
    },
    attendees{
      firstName
      lastName,
      conferences{
        name
      }
    }

  }
}
```
