import React from 'react';
import { useQuery, gql } from "@apollo/client";


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
    
    let returnFragment;
    const { loading, error, data } = useQuery(CONFERENCE_QUERY);

    if (loading) {
        returnFragment = <p>Loading...</p>;
    }
    else if (error) {
        returnFragment =
            <div>
                <pre>{JSON.stringify(error, null, 2)}</pre>
            </div>
    }
    else {
        returnFragment = 
            <div>
                <pre>{JSON.stringify(data, null, 2)}</pre>
            </div>
        
    }

   
    return (
        <div>
            {returnFragment}
        </div>
    );
}