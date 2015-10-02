module Membership {

    export interface IRoleServices {
        addUserToRole(userName: string, roleName: string);
        createRole(name: string);
        findAll(): Role[];
        getByName(roleName: string): Role;
        deleteUser(roleName: string);
        removeUserFromRole(userName: string, roleName: string);
        findRolesForUser(userName: string): Role[];
        findUsersInRole(roleName: string): User[];
    }

    export class RoleServices implements IRoleServices {
        private httpService: any;
        private async: any;

        constructor($http: any, $q: any) {
            this.httpService = $http;
            this.async = $q;
        }

        addUserToRole(userName: string, roleName: string) {
            
        }

        createRole(name: string) {}

        findAll(): Role[] {
             throw new Error("Not implemented");
        }

        getByName(roleName: string): Role {
             throw new Error("Not implemented");
        }

        deleteUser(roleName: string) {}

        removeUserFromRole(userName: string, roleName: string) {}

        findRolesForUser(userName: string): Role[] {
             throw new Error("Not implemented");
        }

        findUsersInRole(roleName: string): User[] {
             throw new Error("Not implemented");
        }
    }
}