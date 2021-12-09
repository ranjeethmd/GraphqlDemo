import React from 'react';
import { useQuery, gql, useLazyQuery } from "@apollo/client";


export const FetchData = () => {

    const CONFERENCE_QUERY = gql`
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
                                }`;

    const PAGE_QUERY = gql`
        query Conferences($skip:Int, $take:Int){
          conferences(skip: $skip, take:$take){
            items{
              id,
              name
            }
          }
        }`;

    const { loading, error, data } = useQuery(CONFERENCE_QUERY);

    const [pagedConference, lazy] = useLazyQuery(PAGE_QUERY);

    
    if (loading) {
        return <p>Loading...</p>;
    }
    else if (lazy.loading) {
        return <p>Loading...</p>;
    }
    else if (error) {
        return (
            <div>
                <button className="btn btn-primary" onClick={() => pagedConference({ variables: { skip: 0, take: 5 } })}>Pagination</button>
                <pre>{JSON.stringify(error, null, 2)}</pre>
            </div>
        );
    }
    else if (lazy.error) {
        return (
            <div>
                <button className="btn btn-primary" onClick={() => pagedConference({ variables: { skip: 0, take: 5 } })}>Pagination</button>
                <pre>{JSON.stringify(lazy.error, null, 2)}</pre>
            </div>
        );
    }
    else if (lazy.data) {
        return (
            <div>
                <button className="btn btn-primary" onClick={() => pagedConference({ variables: { skip: 0, take: 5 } })}>Pagination</button>
                <pre>{JSON.stringify(lazy.data, null, 2)}</pre>
            </div>
        );
    }
    else if (data){

        return (
            <div>
                <button className="btn btn-primary" onClick={() => pagedConference({ variables: { skip: 0, take: 5 } })}>Pagination</button>
                <pre>{JSON.stringify(data, null, 2)}</pre>
            </div>
        );
    }

    
}