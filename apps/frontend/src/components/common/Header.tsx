// import { Link } from "react-scroll";
import { Typography } from "@mui/material";
import { useTranslation } from "react-i18next";

export default function Header() {
  const { t } = useTranslation();

  return (
    <header className="bg-blue-300 text-white px-4 py-6 shadow-md">
      <div className=" container mx-auto flex items-center justify-between">
        <h1 className=" text-2xl font-bold">{t("welcome")}</h1>
        <div className="ml-4 flex items-center space-x-2 sm:space-x-4">
          {/* Desktop Menu */}
          {/* <div className="hidden  lg:flex">
            <div className="ml-4 flex items-center space-x-2 sm:space-x-4  ">
              {navItems.map((item) => (
                <Link
                  key={item.to}
                  to={item.to}
                  smooth={true}
                  duration={500}
                  spy={true}
                  offset={-72}
                  activeClass="active"
                  className="nav-link "
                >
                  <Typography
                    variant="body1"
                    sx={{
                      fontSize: {
                        xs: "12px",
                        sm: "18px",
                        md: "20px",
                        lg: "24px",
                      },
                    }}
                  >
                    {t(item.to)}
                  </Typography>
                </Link>
              ))}
              {/* Language Menu */}
          {/* <LanguageMenu
                isLangEn={isLangEn}
                changeLanguage={changeLanguage}
              />
            </div>
          </div>  */}
          {/* Mobile menu button */}
          {/* <div className="lg:hidden ">
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
          </div> */}
        </div>
      </div>
    </header>
  );
}
