## Simple mutation to add conference.

```
mutation {
  createConference(input:{
    name:"Test Conference"
  })
  {
    conference{
      id,
      name
    }
  }
}
```

## Simple mutation to add track

```
mutation {
  addTrack(input: {
    confrenceId: "Q29uZmVyZW5jZQppMQ==",
    name: "Track1"
      }
    ) {
    track {
      name
      id
    }
  }
}
```

## Simple mutation to add speaker

```
mutation{
  addSpeaker(input:{
    bio:"He does something.",
    name:"Speake1",
    webSite:"https://example.com"
  })
  {
    speaker{
      id
    }
  }
}
```

## Simple mutation to add session

```
mutation{
addSession(input:{
abstract:"We had to conduct some session we are conducting it."
speakerIds:["U3BlYWtlcgppMQ=="],
title:"Enter the dragon."
}){
session{
id,
title
}
}
}

```

## Simple mutation to schedule session

```
mutation{
scheduleSession(input:{
conferenceId:"Q29uZmVyZW5jZQppMQ==",
sessionId:"U2Vzc2lvbgppMQ==",
trackId:"VHJhY2sKaTE=",
startTime:"2020-05-23T15:00:00",
endTime:"2020-05-24T15:00:00"
}){
session{
id
}
}
}

```

## Simple mutation to add attendee

```
mutation{
registerAttendee(input:{
attendeeId:"QXR0ZW5kZWUKaTE=",
conferenceId:"Q29uZmVyZW5jZQppMQ==",
sessionIds:["U2Vzc2lvbgppMQ=="]
}),
{
attendee{
id
}
}
}
```

## Simple mutation to create tag

```
mutation{
createTag(input:{
name: "C#"
}){
tag{
id
}
}
}

```

## Simple mutation to assign tag.

```
mutation{
assignTag(input:{
id:"VGFnCmkx",
sessionIds:["U2Vzc2lvbgppMQ=="]
}){
tag{
name
}
}
}
```
