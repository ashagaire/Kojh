import {
  MenuItem,
  Pagination,
  Select,
  SelectChangeEvent,
  Typography,
} from "@mui/material";
import React from "react";
import { useTranslation } from "react-i18next";
import { PaginationControls } from "../../hooks/usePagination";

interface CustomPaginationProps {
  totalItems: number;
  itemsPerPage: number;
  currentPage: number;
  pagination: PaginationControls;
}

export default function CustomPagination({
  totalItems,
  itemsPerPage,
  currentPage,
  pagination,
}: CustomPaginationProps) {
  const { t } = useTranslation();

  const handleChangePage = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    pagination.setPage(value);
  };

  const handlePageSizeChange = (event: SelectChangeEvent<number>) => {
    pagination.setPageSize(Number(event.target.value));
    pagination.setPage(1);
  };

  return (
    <div
      id="pagination"
      className="grid grid-cols-1 sm:grid-cols-3 gap-4 items-center mt-4"
    >
      <div className="hidden sm:block"></div>
      <Pagination
        count={Math.ceil(totalItems / itemsPerPage)}
        page={currentPage}
        onChange={handleChangePage}
        color="primary"
        className="justify-self-center"
      />
      <div
        id="items-per-page"
        className="flex items-center justify-self-center sm:justify-self-end"
      >
        <Typography variant="body2">{t("itemsPerPage")}:</Typography>
        <Select
          value={itemsPerPage}
          onChange={handlePageSizeChange}
          size="small"
          className="ml-2"
          renderValue={(value) => `${value}`}
          sx={{
            height: "28px",
            minWidth: "20px",
            fontSize: "16px",
            "& .MuiSelect-select": {
              padding: "4px 4px 4px 4px",
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
            },
          }}
        >
          {[5, 10, 15].map((value) => (
            <MenuItem key={value} value={value}>
              {value}
            </MenuItem>
          ))}
        </Select>
      </div>
    </div>
  );
}
