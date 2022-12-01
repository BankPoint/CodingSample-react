using Dapper;
using System.Data.SqlClient;

namespace CodingSample.Model
{
    public interface IDbService
    {
        void AddLoans(List<LoanFileRecord> loans);
        IList<Loan> GetLoans();
    }

    public class DbService : IDbService
    {
        private SqlConnection _con;

        public DbService(SqlConnection con)
        {
            _con = con;
        }

        public void AddLoans(List<LoanFileRecord> loans)
        {
            string sql = $@"
                INSERT INTO Loans 
                (LoanNumber, OriginationDate, OriginalLoanAmount, EffectiveDate, Principal, TotalLoanCommitment, 
                    InterestRate, MaturityDate, AccruedInterest, Escrow) 
                VALUES (@LoanNumber, @OriginationDate, @OriginalLoanAmount, @EffectiveDate, @PrincipalBalance, 
                        @CommitmentAmount, @InterestRate, @MaturityDate, @AccruedInterest, @EscrowBalance)";

            foreach (var item in loans)
            {
                _con.Execute(sql, item);
            }
        }

        public IList<Loan> GetLoans()
        {
            return _con.Query<Loan>(@$"
SELECT l.LoanNumber, l.Principal, l.MaturityDate, CustomerName = c.Name, BranchDescription = b.BranchName
FROM Loans l
LEFT JOIN Customers c ON l.CustomerId = c.Id
LEFT JOIN Branches b ON l.BranchId = b.Id
").ToList();
        }
    }
}
