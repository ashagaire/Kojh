import { NavItem } from "../types/navItems";
import { useTranslation } from "react-i18next";

export const useNavigationItems = (): NavItem[] => {
  const { t } = useTranslation();

  return [
    { to: "about", label: t("about") },
    { to: "projects", label: t("projects") },
    { to: "skills", label: t("skills") },
    { to: "experience", label: t("experience") },
    { to: "education", label: t("education") },
    { to: "contact", label: t("contact") },
  ];
};
