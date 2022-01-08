import React, { lazy, Suspense } from 'react';
import { render, waitFor, screen } from '@testing-library/react';
import "@testing-library/jest-dom"
import { MockedProvider } from '@apollo/client/testing';
import { CONFERENCE_QUERY } from './FetchData';
const FetchData = lazy(() => import('./FetchData'));

it('renders without crashing', async () => {

    const mocks = [{
        request: {
            query: CONFERENCE_QUERY
        },
        result: {
            "data": {
                "conferenceById": {
                    "id": "Q29uZmVyZW5jZQppMQ==",
                    "name": "Test Conference",
                    "tracks": [
                        {
                            "name": "Track1"
                        }
                    ],
                    "sessions": [
                        {
                            "id": "U2Vzc2lvbgppMQ==",
                            "tags": [
                                {
                                    "name": "C#"
                                }
                            ]
                        }
                    ],
                    "attendees": [
                        {
                            "firstName": "Super",
                            "lastName": "Man",
                            "conferences": [
                                {
                                    "name": "Test Conference"
                                }
                            ]
                        }
                    ]
                }
            },
        },
    }];

    const result = render(        
        <Suspense fallback={<div>loading...</div>}>
            <MockedProvider mocks={mocks} addTypename={false}>
                <FetchData />
            </MockedProvider>
            </Suspense>
        
    );

    await new Promise(resolve => setTimeout(resolve, 10));

    await result;

    const pre = (await waitFor(() => document.getElementsByTagName('pre')))[0];

    var resultJson = JSON.parse(pre.textContent);

    /// Json comparison might not happen in the real world. This might be converted to elements instead.

    expect(resultJson).toMatchObject(mocks[0].result.data);
});