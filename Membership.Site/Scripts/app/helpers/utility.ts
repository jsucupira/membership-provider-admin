module Membership.Helpers {
    export class Constants {
        private static domain = "http://localhost:56134";
        static templateBase(): string { return this.domain + "/app/templates"; }
        static apiBase(): string { return this.domain + "/api"; }
        static loginUrl(): string { return this.domain + "/Token"; }
    }
}