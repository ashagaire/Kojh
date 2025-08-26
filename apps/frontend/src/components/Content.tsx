import { Box } from "@mui/material";
interface ContentProps {
  children: React.ReactNode;
}
export default function Content({ children }: ContentProps) {
  return <Box className="flex-grow container mx-auto p-4">{children}</Box>;
}
