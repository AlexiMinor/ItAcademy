import { Guid } from "guid-typescript";

export interface Article {
  articleId: Guid;
  title: string;
  description: string;
  text: string | undefined | null;
  publicationDate?: Date;
  rate?: number;
  sourceName?: string;
}
