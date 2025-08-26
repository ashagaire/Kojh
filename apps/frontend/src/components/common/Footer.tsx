import { useTranslation } from "react-i18next";

export default function Footer() {
  const { t } = useTranslation();
  return (
    <footer className="bg-gray-200 text-center p-4">
      &copy; {new Date().getFullYear()} {t("CompanyDirectory")}. {t("welcome")}
    </footer>
  );
}
