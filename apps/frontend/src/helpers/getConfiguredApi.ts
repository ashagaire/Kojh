import { Api } from "../types/generated/typesApi";
import axios from "axios";

export function getConfiguredApi() {
  axios.defaults.withCredentials = true;

  return new Api(import.meta.env.VITE_API_URL, axios.create());
}
