import React from 'react';
import { useMutation, gql } from "@apollo/client";
import { InteractionType } from "@azure/msal-browser";
import { MsalAuthenticationTemplate } from "@azure/msal-react";

export const UpdateData = () => {

    const CREATE_CONFERENCE = gql`
                                mutation CreateConference($name:String!){
                                  createConference(input:{
                                    name:$name
                                  })
                                  {
                                    conference{
                                      id,
                                      name
                                    }
                                  }
                                }`;

    const [createConference, { data, loading, error }] = useMutation(CREATE_CONFERENCE);

    if (loading) return <div>Submitting...</div>;

    else if (error) {
        return (
            <div>
                <pre>{JSON.stringify(error, null, 2)}</pre>
            </div>
        );
    }

    const createNewConference = async () => {
        try {
            await createConference({ variables: { name: `Apollo Conference ${Math.floor(Math.random() * 10000)}` } });
        }
        catch (error) {
            console.log(error);
        }
    }

    return (
        <MsalAuthenticationTemplate interactionType={InteractionType.Redirect}>
            <div>


                <div><pre>{JSON.stringify(data, null, 2)}</pre></div>



                <button className="btn btn-primary" onClick={createNewConference}>Create</button>
            </div>
        </MsalAuthenticationTemplate>

    );
}