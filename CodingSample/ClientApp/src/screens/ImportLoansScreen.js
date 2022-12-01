import React, {
    Fragment,
    useEffect,
    useRef,
    useState
} from "react";
import {
    useNavigate
} from "react-router-dom";

import { UploadLoansFile } from "../components/Uploader";

function ImportLoansScreen() {
    const fileInput = useRef(null);
    const navigate = useNavigate();
    const [error, setError] = useState(null);

    useEffect(() => {
    }, []);

    const onUploadClick = () => {
        fileInput.current.click();
    };

    const onFileSelected = (evt) => {
        if (evt.target.files && evt.target.files.length > 0) {
            let files = UploadLoansFile(evt.target.files[0]);
            files.catch(e => {
                setError(e);
            });

            files.then(() => {
                navigate("/loans");
            });
        }
    }

    return (
        <Fragment>
            <div className="text-center">
                <h1 id="tabelLabel">Import Loan Data</h1>

                <br />
                <br />
                <button className="btn btn-primary" onClick={onUploadClick}>Upload Loan File</button>

                <div className="invisible">
                    <input id="file-upload" ref={fileInput} name="file-upload" type="file" onChange={onFileSelected} />
                </div>
            </div>
            <pre><br /><br />{error}</pre>
        </Fragment>
    );
}

export { ImportLoansScreen };