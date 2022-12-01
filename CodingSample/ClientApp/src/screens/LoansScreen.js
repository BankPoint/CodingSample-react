import React, {
    Fragment,
    useEffect,
    useState,
} from "react";

function LoansScreen() {
    const [loading, setLoading] = useState(true);
    const [page, setPage] = useState(1);
    const [listResults, setListResults] = useState([]);

    const loadLoans = async () => {
        setLoading(true);
        const url = '/api/loans';
        const response = await fetch(url);
        const data = await response.json();

        setListResults(data);
        setLoading(false);
    };

    useEffect(() => {
        loadLoans();
    }, []);

    let contents = loading
        ? <p><em>Loading...</em></p>
        :
        <div>
            <LoansList listResults={listResults} />
        </div>

    return (
        <Fragment>
            <div>
                <h1 id="tabelLabel">Loans</h1>
                {contents}
            </div>
        </Fragment>
    );
}

const LoansList = ({
    listResults
}) => {
    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th scope="col">Loan Number</th>
                        <th scope="col">Customer Name</th>
                        <th scope="col">Principal</th>
                        <th scope="col">Maturity Date</th>
                        <th scope="col">Branch</th>
                    </tr>
                </thead>
                <tbody>
                    {listResults.pageData.map((loan, idx) => (
                        <LoanItem loan={loan} key={`loan_${idx}`} />
                    ))}
                </tbody>
            </table>
            <div className="row pagination">
                <div className="col-md-12">
                    <button type="button" className="btn btn-default btn-xs mr-5" disabled="disabled">Back</button>
                    <button type="button" className="btn btn-default btn-xs mr-5" disabled="disabled">Next</button>
                    <span className="pageCounts">
                        {listResults.pageStart}-{listResults.pageEnd} of{" "}
                        {listResults.totalCount}
                    </span>
                </div>
            </div>
        </div>
    );
};


const LoanItem = ({ loan, idx }) => {
    return (
        <tr className="text-sm">
            <td>{loan.loanNumber}</td>
            <td>{loan.customerName}</td>
            <td>{loan.principal}</td>
            <td>{loan.maturityDate}</td>
            <td>{loan.branchDescription}</td>
        </tr>
    );
};

export { LoansScreen };