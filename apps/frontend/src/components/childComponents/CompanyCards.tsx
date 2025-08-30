import { useState } from "react";
import { useGetAllCompanies } from "../../hooks/useGetAllCompanies";
import CustomPagination from "../common/pagination";
import { CompanyResponse } from "../../types/generated/typesApi";

export default function CompanyCards() {
  // Create an array with 9 elements
  // const cards = Array.from({ length: 9 });

  const [search, setSearch] = useState("");
  const { data, isLoading, error, pagination } = useGetAllCompanies(search);

  if (isLoading || !data) return <p>Loading companies...</p>;
  if (error instanceof Error) return <p>Error: {error.message}</p>;

  return (
    <div>
      <h1>Company List</h1>

      {/* Search box */}
      <input
        type="text"
        value={search}
        placeholder="Search companies..."
        onChange={(e) => setSearch(e.target.value)}
      />
      {data.companies?.length === 0 && <p>No companies listed yet.</p>}
      <ul>
        {data.companies?.map((company: CompanyResponse) => (
          <li key={company.id}>
            <strong>{company.name}</strong> - {company.accountType} -{" "}
            {company.mainAddress}
          </li>
        ))}
      </ul>

      {/* Pagination controls */}
      {data.totalCount > 0 && (
        <CustomPagination
          totalItems={data.totalCount}
          currentPage={pagination.page}
          itemsPerPage={pagination.pageSize}
          pagination={pagination}
        />
      )}
    </div>
  );
}
