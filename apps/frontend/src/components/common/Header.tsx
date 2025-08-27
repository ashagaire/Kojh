import { useState } from "react";
import MenuIcon from "@mui/icons-material/Menu";
import CloseIcon from "@mui/icons-material/Close";
import SearchIcon from "@mui/icons-material/Search";
import { Typography } from "@mui/material";
import { useTranslation } from "react-i18next";
import LanguageMenu from "../childComponents/LanguageMenu";
import LogIn from "../LogIn";
import Menu from "@mui/material/Menu";
import QuickSearch from "../childComponents/QuickSearch";

export default function Header() {
  const { t } = useTranslation();
  const { i18n } = useTranslation();

  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isLangNp, setIsLangNp] = useState(i18n.language === "en");
  const [loginOpenAnchor, setLoginOpenAnchor] = useState<null | HTMLElement>(
    null
  );

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setLoginOpenAnchor(event.currentTarget);
  };
  const handleCloseUserMenu = () => {
    setLoginOpenAnchor(null);
  };
  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const changeLanguage = (lng: string) => {
    i18n.changeLanguage(lng);
    setIsLangNp(lng === "en");
    setIsMenuOpen(false);
  };

  return (
    <header className="bg-blue-300 text-white px-4 py-6 shadow-md">
      <div className="container mx-auto flex items-center justify-between">
        <h1 className="text-2xl font-bold">{t("welcome")}</h1>
        <div className="ml-4 flex items-center space-x-2 sm:space-x-4">
          {/* Desktop Menu */}
          <div className="hidden lg:flex">
            <div className="ml-4 flex items-center space-x-2 sm:space-x-4">
              {/* Search menu */}
              <div>
                <QuickSearch />
              </div>
              {/* Login Button */}
              <div>
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
              {/* Language Menu */}
              <LanguageMenu
                isLangEn={isLangNp}
                changeLanguage={changeLanguage}
              />
            </div>
          </div>
          {/* Mobile menu button */}
          <div className="lg:hidden ">
            <button
              onClick={toggleMenu}
              className="text-[#d92cf9] hover:text-purple-600 focus:outline-none"
            >
              {isMenuOpen ? (
                <CloseIcon fontSize="large" />
              ) : (
                <MenuIcon fontSize="large" />
              )}
            </button>
          </div>
        </div>
      </div>
      {/* Login Modal */}
    </header>
  );
}
