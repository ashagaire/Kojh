export interface CompanyResponse {
  id: string;
  name: string;
  accountType: string;
  mainAddress: string;
  // other fields can be added later
}

export interface PaginatedCompanyResponse {
  totalCount: number;
  companies: CompanyResponse[];
}

export interface CompanyListFilter {
  search: string;
  currentPage: number;
  pageSize: number;
}

import client from "./client";

export const getAllCompanies = async (filter: CompanyListFilter) => {
  const response = await client.post<PaginatedCompanyResponse>("/company/all", {
    body: filter,
  });
  return response.data;
};
