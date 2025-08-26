import { Box } from "@mui/material";
import Content from "./Content";
import Header from "./common/Header";
import Footer from "./common/Footer";
interface LayoutProps {
  children: React.ReactNode;
}

export default function Layout({ children }: LayoutProps) {
  return (
    <Box sx={{ display: "flex", flexDirection: "column", minHeight: "100vh" }}>
      <Header />
      <Content children={children} />
      <Footer />
    </Box>
  );
}
