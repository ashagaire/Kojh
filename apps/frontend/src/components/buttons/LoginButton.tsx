import { Typography, Menu } from "@mui/material";
import LogIn from "../LogIn";
import { useState } from "react";
import { Accordion, AccordionSummary, AccordionDetails } from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

interface LoginButtonProps {
  loginOpenAnchor: null | HTMLElement;
  handleOpenUserMenu: (event: React.MouseEvent<HTMLElement>) => void;
  handleCloseUserMenu: () => void;
}

export default function LoginButton({
  loginOpenAnchor,
  handleOpenUserMenu,
  handleCloseUserMenu,
}: LoginButtonProps) {
  const [loginOpen, setLoginOpen] = useState(false);

  return (
    <div>
      <div className="border-l-2 border-[#d92cf9] pl-2 h-10 flex items-center hidden lg:flex">
        <Typography
          sx={{
            cursor: "pointer",
            color: "white",
            fontWeight: 500,
          }}
          onClick={handleOpenUserMenu}
        >
          LogIn
        </Typography>
        <Menu
          sx={{ mt: "45px" }}
          id="menu-login"
          anchorEl={loginOpenAnchor}
          anchorOrigin={{
            vertical: "top",
            horizontal: "right",
          }}
          keepMounted
          transformOrigin={{
            vertical: "top",
            horizontal: "right",
          }}
          open={Boolean(loginOpenAnchor)}
          onClose={handleCloseUserMenu}
        >
          <LogIn />
        </Menu>
      </div>
      {/* Open Login component in Accordion for small screen*/}
      <div className="lg:hidden ">
        <div style={{ minWidth: 100 }}>
          <Accordion
            expanded={loginOpen}
            onChange={() => setLoginOpen(!loginOpen)}
            sx={{
              background: "transparent",
              boxShadow: "none",
              color: "inherit",
            }}
          >
            <AccordionSummary
              expandIcon={<ExpandMoreIcon sx={{ color: "white" }} />}
              aria-controls="login-content"
              id="login-header"
              sx={{ padding: 0, minHeight: 0 }}
            >
              <Typography
                sx={{ cursor: "pointer", color: "white", fontWeight: 500 }}
              >
                LogIn
              </Typography>
            </AccordionSummary>
            <AccordionDetails sx={{ background: "#fff", color: "#222", p: 2 }}>
              <LogIn />
            </AccordionDetails>
          </Accordion>
        </div>
      </div>
    </div>
  );
}
