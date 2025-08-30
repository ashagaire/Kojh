// src/hooks/useGetAllCompanies.ts
import { useQuery } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { usePagination } from "./usePagination";
import { QUERY_KEYS } from "../utils/queryKeys";
import { PaginatedCompanyResponse } from "../types/generated/typesApi";
import { getConfiguredApi } from "../helpers/getConfiguredApi";
import { CompanyListFilter } from "../types/generated/typesApi";

export function useGetAllCompanies(search: string) {
  const api = getConfiguredApi();
  const pagination = usePagination();

  const query = useQuery<PaginatedCompanyResponse, Error | AxiosError>({
    queryKey: QUERY_KEYS.allCompanies({
      page: pagination.page,
      pageSize: pagination.pageSize,
      search,
    }),
    queryFn: async () => {
      const result = await api.getAllCompanies({
        search,
        currentPage: pagination.page,
        pageSize: pagination.pageSize,
      } as CompanyListFilter);
      pagination.setTotalCount(result.totalCount);
      return result;
    },
    placeholderData: (previous) => previous, // keeps old data during refetch
  });

  return { ...query, pagination };
}
