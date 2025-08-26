import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import { initReactI18next } from "react-i18next";
import enLang from "./locales/en.json";
import npLang from "./locales/np.json";

const resources = {
  en: { translation: enLang },
  np: { translation: npLang },
};

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    resources,

    fallbackLng: "np",
    lng: "np",
    supportedLngs: ["en", "np"],
    interpolation: {
      escapeValue: false,
    },
  });

export default i18n;
