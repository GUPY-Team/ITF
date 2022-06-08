import {render} from '@testing-library/react'
import '@testing-library/jest-dom'
import App from "./App";

describe("TEST", () => {
    it("Should run", ()=> {
        const {getByText} = render(App);
        expect(2+2).toBe(4);
    })
    
})