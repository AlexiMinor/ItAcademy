import { Guid } from 'guid-typescript';
import { Article } from './article';

export const ARTICLES_STORAGE: Article[] = [
  {
    articleId: Guid.create(),
    title: 'Article #1',
    description: 'Article description #1',
    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus massa vel diam tempor tempor. Maecenas lobortis in nibh vel porta. Sed imperdiet hendrerit metus, sed viverra magna finibus eget. Nulla justo ex, finibus eu ex et, bibendum ullamcorper mauris. Duis egestas pellentesque massa, vel cursus tortor auctor eget. Donec et tincidunt urna. Vestibulum sit amet sapien id ex iaculis egestas eu lobortis metus. Nullam auctor gravida est non consequat. Fusce in sollicitudin est. Fusce euismod mollis egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam at erat nisl. Cras malesuada, dolor ac consectetur ultricies, elit nulla commodo turpis, in consectetur purus elit at ex. Praesent sapien eros, accumsan et bibendum ultrices, varius vitae nisl. Cras a aliquam ex. Nunc dictum dictum imperdiet.',
    rate: 2,
  },
  {
    articleId: Guid.create(),
    title: 'Article #2',
    description: 'Article description 2',
    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus massa vel diam tempor tempor. Maecenas lobortis in nibh vel porta. Sed imperdiet hendrerit metus, sed viverra magna finibus eget. Nulla justo ex, finibus eu ex et, bibendum ullamcorper mauris. Duis egestas pellentesque massa, vel cursus tortor auctor eget. Donec et tincidunt urna. Vestibulum sit amet sapien id ex iaculis egestas eu lobortis metus. Nullam auctor gravida est non consequat. Fusce in sollicitudin est. Fusce euismod mollis egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam at erat nisl. Cras malesuada, dolor ac consectetur ultricies, elit nulla commodo turpis, in consectetur purus elit at ex. Praesent sapien eros, accumsan et bibendum ultrices, varius vitae nisl. Cras a aliquam ex. Nunc dictum dictum imperdiet.',
  },
  {
    articleId: Guid.create(),
    title: 'Article #3',
    description: 'Article description 3',
    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus massa vel diam tempor tempor. Maecenas lobortis in nibh vel porta. Sed imperdiet hendrerit metus, sed viverra magna finibus eget. Nulla justo ex, finibus eu ex et, bibendum ullamcorper mauris. Duis egestas pellentesque massa, vel cursus tortor auctor eget. Donec et tincidunt urna. Vestibulum sit amet sapien id ex iaculis egestas eu lobortis metus. Nullam auctor gravida est non consequat. Fusce in sollicitudin est. Fusce euismod mollis egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam at erat nisl. Cras malesuada, dolor ac consectetur ultricies, elit nulla commodo turpis, in consectetur purus elit at ex. Praesent sapien eros, accumsan et bibendum ultrices, varius vitae nisl. Cras a aliquam ex. Nunc dictum dictum imperdiet.',
  },
  {
    articleId: Guid.create(),
    title: 'Article #4',
    description: 'Article description 4',
    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus massa vel diam tempor tempor. Maecenas lobortis in nibh vel porta. Sed imperdiet hendrerit metus, sed viverra magna finibus eget. Nulla justo ex, finibus eu ex et, bibendum ullamcorper mauris. Duis egestas pellentesque massa, vel cursus tortor auctor eget. Donec et tincidunt urna. Vestibulum sit amet sapien id ex iaculis egestas eu lobortis metus. Nullam auctor gravida est non consequat. Fusce in sollicitudin est. Fusce euismod mollis egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam at erat nisl. Cras malesuada, dolor ac consectetur ultricies, elit nulla commodo turpis, in consectetur purus elit at ex. Praesent sapien eros, accumsan et bibendum ultrices, varius vitae nisl. Cras a aliquam ex. Nunc dictum dictum imperdiet.',
    rate: 15,
  },
  {
    articleId: Guid.create(),
    title: 'Article #5',
    description: 'Article description 5',
    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus massa vel diam tempor tempor. Maecenas lobortis in nibh vel porta. Sed imperdiet hendrerit metus, sed viverra magna finibus eget. Nulla justo ex, finibus eu ex et, bibendum ullamcorper mauris. Duis egestas pellentesque massa, vel cursus tortor auctor eget. Donec et tincidunt urna. Vestibulum sit amet sapien id ex iaculis egestas eu lobortis metus. Nullam auctor gravida est non consequat. Fusce in sollicitudin est. Fusce euismod mollis egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam at erat nisl. Cras malesuada, dolor ac consectetur ultricies, elit nulla commodo turpis, in consectetur purus elit at ex. Praesent sapien eros, accumsan et bibendum ultrices, varius vitae nisl. Cras a aliquam ex. Nunc dictum dictum imperdiet.',
    rate: -20,
  },
];
