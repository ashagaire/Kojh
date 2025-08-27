import LanguageMenu from "../buttons/LanguageMenu";
import LoginButton from "../buttons/LoginButton";

interface MobileMenuProps {
  isMenuOpen: boolean;
  setIsMenuOpen: (isOpen: boolean) => void;
  isLangEn: boolean;
  changeLanguage: (lng: string) => void;
  loginOpenAnchor: null | HTMLElement;
  handleOpenUserMenu: (event: React.MouseEvent<HTMLElement>) => void;
  handleCloseUserMenu: () => void;
}

export default function MobileMenu({
  isMenuOpen,
  setIsMenuOpen,
  isLangEn,
  changeLanguage,
  loginOpenAnchor,
  handleOpenUserMenu,
  handleCloseUserMenu,
}: MobileMenuProps) {
  if (!isMenuOpen) return null;

  return (
    <div
      className="fixed inset-0 z-50 bg-black bg-opacity-10 lg:hidden mt-14 sm:mt-16 md:mt-2018  "
      onClick={() => setIsMenuOpen(false)}
    >
      <div
        className="absolute left-0 right-0 px-2 pt-2  pb-3 space-y-1 bg-[#d92cf9] shadow-lg"
        onClick={(e) => e.stopPropagation()}
      >
        <LoginButton
          loginOpenAnchor={loginOpenAnchor}
          handleOpenUserMenu={handleOpenUserMenu}
          handleCloseUserMenu={handleCloseUserMenu}
        />
        <LanguageMenu
          isLangEn={isLangEn}
          changeLanguage={changeLanguage}
          isMobile={true}
        />
      </div>
    </div>
  );
}
