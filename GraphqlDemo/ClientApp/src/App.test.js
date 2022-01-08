import { App } from './App';
import React from 'react';
import { render } from '@testing-library/react';

it('renders without crashing', async () => {
    render(<App/>)
});
