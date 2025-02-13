PGDMP      
            
    |            HomeAccounting    15.8    16.4                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16394    HomeAccounting    DATABASE     �   CREATE DATABASE "HomeAccounting" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
     DROP DATABASE "HomeAccounting";
                postgres    false            �            1259    16396    Purchase    TABLE     �   CREATE TABLE public."Purchase" (
    "Id" integer NOT NULL,
    "CategoryId" integer NOT NULL,
    "CreatorUserId" integer NOT NULL,
    "Amount" integer NOT NULL,
    "Comment" text,
    "Date" timestamp with time zone NOT NULL
);
    DROP TABLE public."Purchase";
       public         heap    postgres    false            �            1259    16404    PurchaseCategory    TABLE     {   CREATE TABLE public."PurchaseCategory" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Color" text NOT NULL
);
 &   DROP TABLE public."PurchaseCategory";
       public         heap    postgres    false            �            1259    16403    PurchaseCategory_Id_seq    SEQUENCE     �   ALTER TABLE public."PurchaseCategory" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."PurchaseCategory_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    16395    Purchase_Id_seq    SEQUENCE     �   ALTER TABLE public."Purchase" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Purchase_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    16412    Users    TABLE     �   CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    "Name" text NOT NULL
);
    DROP TABLE public."Users";
       public         heap    postgres    false            �            1259    16411    Users_Id_seq    SEQUENCE     �   ALTER TABLE public."Users" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219                      0    16396    Purchase 
   TABLE DATA           f   COPY public."Purchase" ("Id", "CategoryId", "CreatorUserId", "Amount", "Comment", "Date") FROM stdin;
    public          postgres    false    215   Y                 0    16404    PurchaseCategory 
   TABLE DATA           C   COPY public."PurchaseCategory" ("Id", "Name", "Color") FROM stdin;
    public          postgres    false    217   �                 0    16412    Users 
   TABLE DATA           D   COPY public."Users" ("Id", "Login", "Password", "Name") FROM stdin;
    public          postgres    false    219   x                  0    0    PurchaseCategory_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."PurchaseCategory_Id_seq"', 6, false);
          public          postgres    false    216                       0    0    Purchase_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Purchase_Id_seq"', 8, false);
          public          postgres    false    214                       0    0    Users_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Users_Id_seq"', 3, false);
          public          postgres    false    218            p           2606    16402    Purchase PK_Purchase 
   CONSTRAINT     X   ALTER TABLE ONLY public."Purchase"
    ADD CONSTRAINT "PK_Purchase" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Purchase" DROP CONSTRAINT "PK_Purchase";
       public            postgres    false    215            r           2606    16410 $   PurchaseCategory PK_PurchaseCategory 
   CONSTRAINT     h   ALTER TABLE ONLY public."PurchaseCategory"
    ADD CONSTRAINT "PK_PurchaseCategory" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."PurchaseCategory" DROP CONSTRAINT "PK_PurchaseCategory";
       public            postgres    false    217            t           2606    16418    Users PK_Users 
   CONSTRAINT     R   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "PK_Users";
       public            postgres    false    219               d   x�m�A
�0D�uz
�R�IE�	z�sX��Q!���PT(��В��u �~#,��f�o?��@��S10���b�-���P��)�t 	q-          �   x�-�=
�P���S����;���=T�6>i-��`H0$^a�FNa3���wK��m'|,�%���xsY���O�hّ��R2�ӱ�F���eD
�#�J�Q[&�ع�NW�[:j���~wЩ���%Z�gT��E���@U�^�         .   x�3�t�/"NC#c��ļ�T.#΂�N΀���D�=... ٵ
     