export class User {
    id: number | undefined;
    name!: string;
    password!: string;
    email!: string;
    department!: string;
    role!: string;

    isValid(): boolean {
        const areStringsValid =
        !!this.name && !!this.password && !!this.email && !!this.department && !!this.role;

        return areStringsValid;
    }
}