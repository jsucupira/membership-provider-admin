module Membership.Helpers {
    export class Constants {
        private static domain = "http://localhost:58133";
        static get templateBase(): string { return this.domain + "/app/templates"; }
        static get apiBase(): string { return this.domain + "/api"; }
        static get loginUrl(): string { return this.domain + "/Token"; }
    }
}