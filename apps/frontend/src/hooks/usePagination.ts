import { useEffect, useState } from "react";

export type PaginationControls = {
  page: number;
  pageSize: number;
  pages?: number;
  totalCount?: number;
  setPage: (page: number) => void;
  setPageSize: (pageSize: number) => void;
  setTotalCount: (totalCount: number) => void;
};

type IUsePagination = {
  defaultPage?: number;
  defaultPageSize?: number;
};

const defaultSettings = {
  defaultPage: 1,
  defaultPageSize: 5,
};

export function usePagination(settings?: IUsePagination) {
  const [page, setPage] = useState(settings?.defaultPage ?? 1);
  const [pageSize, setPageSize] = useState(
    settings?.defaultPageSize ?? defaultSettings.defaultPageSize
  );
  const [pages, setPages] = useState<number | undefined>(undefined);
  const [totalCount, setTotalCount] = useState<number | undefined>(50);

  useEffect(() => {
    if (totalCount === undefined) return;
    if (totalCount === 0) {
      setPages(1);
      return;
    }
    setPages(Math.ceil(totalCount / pageSize));
  }, [totalCount, setPages, pageSize]);

  useEffect(() => {
    if (pages && page > pages) setPage(1);
  }, [page, setPage, pages]);

  const changePage = (page: number) => {
    if (page < 1) return;
    if (page > Math.ceil(totalCount ?? 0 / pageSize)) return;
    setPage(page);
  };

  return {
    page,
    setPage: changePage,
    pages,
    pageSize,
    setPageSize,
    totalCount,
    setTotalCount,
  };
}
