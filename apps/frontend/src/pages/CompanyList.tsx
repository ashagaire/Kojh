import React, { useEffect, useState } from "react";
import {
  getAllCompanies,
  CompanyResponse,
  CompanyListFilter,
} from "../api/company";

const CompanyList: React.FC = () => {
  const [companies, setCompanies] = useState<CompanyResponse[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [currentPage, setCurrentPage] = useState(1);

  const fetchCompanies = async (page = 1) => {
    setLoading(true);
    setError("");
    try {
      const filter: CompanyListFilter = {
        search: "",
        currentPage: page,
        pageSize: 5,
      };
      const data = await getAllCompanies(filter);
      setCompanies(data.companies);
      setCurrentPage(page);
    } catch (err: any) {
      setError(err.message || "Failed to fetch companies");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCompanies();
  }, []);

  if (loading) return <p>Loading companies...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div>
      <h1>Company List</h1>
      <ul>
        {companies.map((company) => (
          <li key={company.id}>
            <strong>{company.name}</strong> - {company.accountType} -{" "}
            {company.mainAddress}
          </li>
        ))}
      </ul>

      {/* Simple pagination */}
      <button
        onClick={() => fetchCompanies(currentPage - 1)}
        disabled={currentPage <= 1}
      >
        Previous
      </button>
      <span> Page {currentPage} </span>
      <button onClick={() => fetchCompanies(currentPage + 1)}>Next</button>
    </div>
  );
};

export default CompanyList;
