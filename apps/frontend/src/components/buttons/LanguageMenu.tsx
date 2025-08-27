import React from "react";
import ReactCountryFlag from "react-country-flag";

interface LanguageMenuProps {
  isLangEn: boolean;
  changeLanguage: (lng: string) => void;
  isMobile?: boolean;
}

const LanguageMenu: React.FC<LanguageMenuProps> = ({
  isLangEn,
  changeLanguage,
  isMobile = false,
}) => {
  return (
    <div
      className={`${
        isMobile
          ? "px-3 text-white block text-lg font-bold"
          : "flex justify-center items-center border-l-2 border-[#d92cf9] pl-2 h-10"
      } cursor-pointer`}
    >
      {isLangEn ? (
        <div className="flex space-x-2" onClick={() => changeLanguage("np")}>
          <p>{isMobile ? "NP" : ""}</p>
          <ReactCountryFlag
            countryCode={"NP"}
            svg
            style={{
              width: isMobile ? "30px" : "40px",
              height: isMobile ? "30px" : "30px",
            }}
          />
        </div>
      ) : (
        <div className="flex space-x-2" onClick={() => changeLanguage("en")}>
          <p>{isMobile ? "EN" : ""}</p>
          <ReactCountryFlag
            countryCode={"GB"}
            svg
            style={{
              width: isMobile ? "30px" : "40px",
              height: isMobile ? "30px" : "30px",
            }}
          />
        </div>
      )}
    </div>
  );
};

export default LanguageMenu;
