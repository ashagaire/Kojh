// src/hooks/useGetAllCompanies.ts
import { useQuery } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { getAllCompanies } from "./api/company";
import { usePagination } from "./usePagination";
import { QUERY_KEYS } from "../utils/queryKeys";
import { PaginatedCompanyResponse } from "../types/generated/ClientApi";

export function useGetAllCompanies(search: string) {
  const pagination = usePagination();

  const query = useQuery<PaginatedCompanyResponse, Error | AxiosError>({
    queryKey: QUERY_KEYS.allCompanies({
      page: pagination.page,
      pageSize: pagination.pageSize,
      search,
    }),
    queryFn: async () => {
      const result = await getAllCompanies({
        search,
        currentPage: pagination.page,
        pageSize: pagination.pageSize,
      });
      pagination.setTotalCount(result.totalCount);
      return result;
    },
    placeholderData: (previous) => previous, // keeps old data during refetch
  });

  return { ...query, pagination };
}
