const UploadLoansFile = (file) => {
    const url = `/api/loans`;
    const formData = new FormData();
    formData.append("formFile", file, file.name);

    return new Promise((resolve, reject) => {
        const req = new XMLHttpRequest();

        req.upload.addEventListener("progress", (evt) => {
            if (evt.lengthComputable) {
                let percentage = (evt.loaded / evt.total) * 100;
                //onProgress({
                //    file: fileItem,
                //    status: "pending",
                //    percentage: percentage,
                //});
            }
        });

        // needed to catch low level send errors, such as file too large
        // the reject call ensures that the upload error event listener gets an opportunity
        // to handle this.
        req.onreadystatechange = () => {
            if (req.readyState === XMLHttpRequest.DONE) {
                if (req.status === 200) {
                    resolve(req.response);
                } else {
                    reject(req.response);
                }
            }
        };

        req.open("POST", url);
        //req.setRequestHeader("Authorization", authInfo.bearerString())
        req.send(formData);
    });
}

export { UploadLoansFile };