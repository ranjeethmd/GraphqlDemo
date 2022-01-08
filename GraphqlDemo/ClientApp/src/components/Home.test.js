import React, { lazy, Suspense } from 'react';
import { render, waitFor } from '@testing-library/react';
import "@testing-library/jest-dom"

const Home = lazy( () => import( './Home'));

it('renders without crashing', async () => {

    const { getByText } = render(
        <Suspense fallback={<div>loading...</div>}>
            <Home />
        </Suspense>
    );

    const home = await waitFor(() => getByText("Hello, world!"));

    expect(home).toHaveTextContent("Hello, world!");
});
