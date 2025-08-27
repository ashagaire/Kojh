import { useState } from "react";
import MenuIcon from "@mui/icons-material/Menu";
import { useTranslation } from "react-i18next";

import LanguageMenu from "../buttons/LanguageMenu";
import QuickSearch from "../childComponents/QuickSearch";
import LoginButton from "../buttons/LoginButton";
import MobileMenu from "../childComponents/MobileMenu";

export default function Header() {
  const { t } = useTranslation();
  const { i18n } = useTranslation();

  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isLangEn, setIsLangEn] = useState(i18n.language === "en");
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
    setIsLangEn(lng === "en");
    setIsMenuOpen(false);
  };

  return (
    <header className="bg-blue-300 text-white px-4 py-6 shadow-md">
      <div className="container mx-auto flex items-center justify-between">
        <h1 className="text-2xl font-bold">{t("welcome")}</h1>
        <div className="ml-4 flex items-center space-x-2 sm:space-x-4">
          <div className="ml-4 flex items-center space-x-2 sm:space-x-4">
            {/* Search menu */}
            <div>
              <QuickSearch />
            </div>
            {/* Desktop Menu */}
            <div className="hidden lg:flex">
              {/* Login Button */}

              <LoginButton
                loginOpenAnchor={loginOpenAnchor}
                handleOpenUserMenu={handleOpenUserMenu}
                handleCloseUserMenu={handleCloseUserMenu}
              />
              {/* Language Menu */}
              <LanguageMenu
                isLangEn={isLangEn}
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
              <MenuIcon fontSize="large" />
            </button>
          </div>
        </div>
        <MobileMenu
          isMenuOpen={isMenuOpen}
          setIsMenuOpen={setIsMenuOpen}
          isLangEn={isLangEn}
          changeLanguage={changeLanguage}
          loginOpenAnchor={loginOpenAnchor}
          handleOpenUserMenu={handleOpenUserMenu}
          handleCloseUserMenu={handleCloseUserMenu}
        />
      </div>
    </header>
  );
}
