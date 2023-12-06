import React, {useState} from 'react';
import {Button} from "reactstrap";
import {useAuth0} from "@auth0/auth0-react";

const Lab1 = () => {
    const {getAccessTokenSilently} = useAuth0();
    const [input, setInput] = useState<string>('')
    const [output, setOutput] = useState<string | null>(null)

    const handleRunLab = async () => {
        const res = await fetch('https://localhost:7054/lab/lab1', {
            body: input,
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${await getAccessTokenSilently()}`,
                'Content-Type': 'text/plain'
            },
        })

        if (res.ok) {
            setOutput(await res.text())
        }
    }

    return (
        <div className="d-flex flex-column gap-2 align-items-start">
            <h1>Lab 1 Rybak</h1>
            <label htmlFor="textarea">Enter input:</label>
            <textarea value={input} onChange={(e) => setInput(e.target.value)} cols={50} rows={10} name="data"
                      id="textarea"></textarea>
            <Button onClick={handleRunLab} color="primary">Submit</Button>
            {output && (
                <div className="d-flex gap-2">
                    <label>Result:</label>
                    <div>{output}</div>
                </div>
            )}
        </div>
    );
};

export default Lab1;