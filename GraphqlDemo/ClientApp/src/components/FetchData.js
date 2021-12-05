import React from 'react';
import { useQuery, gql } from "@apollo/client";
import { InteractionType } from "@azure/msal-browser";
import { MsalAuthenticationTemplate } from "@azure/msal-react";

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

    const { loading, error, data } = useQuery(CONFERENCE_QUERY);

    let returnFragment;

    if (loading) {
        returnFragment = <p>Loading...</p>;
    }
    else if (error) {
        returnFragment = <p>Error : {error}</p>
    }
    else {
        returnFragment =
            <div>
                <div>
                    <pre>{JSON.stringify(data, null, 2)}</pre>
                </div>
            </div>
    }

    return (
        <MsalAuthenticationTemplate interactionType={InteractionType.Redirect}>
            {returnFragment}
        </MsalAuthenticationTemplate>
    );
}